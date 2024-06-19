import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import CampaignOutlinedIcon from '@mui/icons-material/CampaignOutlined';
import IconButton from '@mui/material/IconButton';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';

const Announcement = () => {
    return (
        <Box sx={{ width: '100%', padding: '10px', marginBottom: '16px', backgroundColor: '#2d2d2d' }}>
            <IconButton
                sx={{
                    borderRadius: '50%',
                    backgroundColor: 'rgba(0,0,0,.17)',
                    padding: '4px',
                    cursor: 'auto',
                    '&:hover': { backgroundColor: 'rgba(0,0,0,.17)' },
                }}
            >
                <CampaignOutlinedIcon />
            </IconButton>
            <List sx={{ paddingLeft: '40px', paddingY: '0', marginTop: '-12px' }}>
                <ListItem disablePadding>
                    <Typography sx={{ color: '#f3dd3d', fontSize: '22px', fontWeight: '300', paddingBottom: '16px' }}>
                        Lưu hoặc nhớ ngay link rút gọn{' '}
                        <Box
                            component={'a'}
                            href="/"
                            sx={{ textDecoration: 'none', color: 'text.primary', '&:hover': { opacity: '0.5' } }}
                        >
                            bit.ly/animevietsubtv
                        </Box>{' '}
                        để truy cập khi nhà mạng chặn!
                    </Typography>
                </ListItem>
                <ListItem disablePadding>
                    <Typography sx={{ color: '#f3dd3d', fontSize: '22px', fontWeight: '300', paddingBottom: '16px' }}>
                        Mời bạn tham gia Group{' '}
                        <Box component={'a'} href="/" sx={{ textDecoration: 'none', color: '#e62117' }}>
                            tại đây!
                        </Box>{' '}
                        hoặc tham gia Discord{' '}
                        <Box component={'a'} href="/" sx={{ textDecoration: 'none', color: '#e62117' }}>
                            tại đây!
                        </Box>{' '}
                        để ủng hộ{' '}
                        <Box color={'#e62117'} component={'span'}>
                            AnimeVietsub
                        </Box>
                    </Typography>
                </ListItem>
                <ListItem disablePadding>
                    <Typography sx={{ color: '#f3dd3d', fontSize: '22px', fontWeight: '300', paddingBottom: '16px' }}>
                        Do thiếu hụt kinh phí nên quảng cáo có thể gây khó chịu, rất mong các bạn thông cảm!
                    </Typography>
                </ListItem>
            </List>
        </Box>
    );
};

export default Announcement;
